from datetime import date , datetime
from os import error, name
from random import seed
import re
from flask import Flask, render_template, flash, redirect, url_for, session, request
import pymongo
from typing import Text
from wtforms import Form, StringField, EmailField, PasswordField, validators
from functools import wraps
from passlib.hash import sha256_crypt
import json 
from bson.objectid import ObjectId
from wtforms.fields.simple import TextAreaField

app = Flask(__name__)

def cannot_connect(e):
    return render_template('404.html')

ENV = 'prod'

if ENV == 'dev':
    app.debug = True
    try:
        mongo = pymongo.MongoClient(
            host='mongodb://127.0.0.1:27017/'
        )
        mongo.server_info()
        if mongo.server_info():
            print('Successfully connected to the db')
            db = mongo.clients
            dbQandA = mongo.qanda
    except:
        print('ERROR - Cannot connect to the db')
elif ENV == 'prod':
    app.debug = False
    try:
        mongo = pymongo.MongoClient(host='mongodb+srv://grayroot:gray100@testcluster1.6majs.mongodb.net/clients?retryWrites=true&w=majority')
        mongo.server_info()
        if mongo.server_info():
            print('Successfully connected to the db')
            db = mongo.clients
            dbQandA = mongo.qanda
    except:
        print('ERROR - Cannot connect to the db')

class QForm(Form):
    name = StringField('Name', [validators.length(min=1, max=50)])
    title = StringField('Title',[validators.length(min=1, max=255)])
    question = TextAreaField('Question',[validators.length(min=20)])

class AForm(Form):
    answer = TextAreaField('Answer',[validators.length(min=20)])

class RForm(Form):
    name = StringField('Name', [validators.length(min=1, max=50)])
    repost = TextAreaField('Re-Post',[validators.length(min=20)])

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/questions')
def questions():
    questions = dbQandA.questions.find()
    answers = dbQandA.answers.find()
    if questions:
        return render_template('questions.html', questions = questions, answers = answers)
    else:
        msg = 'No question found'
        return render_template('questions.html', msg = msg)

@app.route('/answers/<string:id>', methods = ['GET','POST'])
def answers(id):
    questions = dbQandA.questions.find({"_id":ObjectId(id)})
    answers = dbQandA.answers.find({"q_id":ObjectId(id)})
    if questions:
         return render_template('answers.html', questions = questions, answers = answers, id= id)
    else:
       return render_template('answers.html')


@app.route('/re_post/<string:id>', methods = ['GET','POST'])
def re_post(id):
    answers = dbQandA.answers.find({"q_id":ObjectId(id)})
    form = RForm(request.form)
    if request.method == 'POST' and form.validate():
        name = form.name.data
        repost = form.repost.data
        rData ={
            "q_id":ObjectId(id),
            "answer": repost,
            "answered_by":name,
            "answer_date":datetime.now()
        }
        dbResponse = dbQandA.answers.insert_one(rData)
        print(dbResponse)
        if dbResponse:
            flash('Your answer is posted', 'success')
            return redirect(url_for('answers', id = id))
        else:
            flash('Something went wrong', 'danger')
            return redirect(url_for('answers', id = id))

    return render_template('re_post.html', form = form, answers = answers)

@app.route('/askquestion', methods = ['GET','POST'])
def askquestion():
    form = QForm(request.form)
    if request.method == 'POST' and form.validate():
        name = form.name.data
        title = form.title.data
        question = form.question.data
        qData = {
            "name":name,
            "title":title,
            "question":question,
            "question_date": datetime.now()
            }
        #insert into the collection and get the collection
        dbResponse = dbQandA.questions.insert_one(qData)
        if dbResponse:
            flash('Your question is posted', 'success')
            return redirect(url_for('questions'))
        else:
            flash('Somthing went wrong','danger')
    return render_template('askquestion.html', form = form)

class RegisterForm(Form):
    name = StringField('Name',[validators.Length(min=1,max=30)])
    username = StringField('Username',[validators.Length(min=4,max=25)])
    email = EmailField('Email',[validators.Length(min=6,max=50)])
    password = PasswordField('Password', [
        validators.DataRequired(),
        validators.EqualTo('confirm',message='Password do not match')
    ])
    confirm = PasswordField('Confirm Password')

@app.route('/register', methods=['GET','POST'])
def create_user():
    #Create the instance of the register class
    form = RegisterForm(request.form)
    if request.method == 'POST' and form.validate():
        name = form.name.data
        email = form.email.data
        username = form.username.data
        password = sha256_crypt.encrypt(str(form.password.data))
        #Create collection
        user = {
            "name":name,
            "email":email,
            "username":username,
            "password":password
            }
        #insert into the collection and get the collection
        dbResponse = db.members.insert_one(user)
        if dbResponse:
            flash('You are now registered, please login', 'success')
            return redirect(url_for('login'))
        else:
            flash('Somthing went wrong','danger')
    return render_template('register.html', form = form)

def is_logged_in(f):
    @wraps(f)
    def wrap(*args,**kwargs):
        if 'logged_in' in session:
            return f(*args, **kwargs)
        else:
            flash('Unauthorized, Please Login','danger')
            return redirect(url_for('login'))
    return wrap

@app.route('/login', methods=['GET','POST'])
def login():
    if request.method == 'POST':
        username = request.form['username']
        password_candidate = request.form['password']
        data = db.members.find({'username':username})
        if data:
            for member in data:
                password = member['password']
                if sha256_crypt.verify(password_candidate,password):
                    session['logged_in'] = True
                    session['name'] = member['name']
                    session['username'] = username
                    flash('You are now logged in','success')
                    return redirect(url_for('dashboard'))
                else:
                    error = 'Invalid Login'
                    return render_template('login.html', error= error)   
        elif data == False:
            error = 'User not found'
            return render_template('login.html', error= error) 

    return render_template('login.html')

@app.route('/dashboard')
@is_logged_in 
def dashboard():
    questions = dbQandA.questions.find()
    answers = dbQandA.answers.find()
    if questions:
        return render_template('dashboard.html', questions = questions, answers = answers)
    else:
        msg = 'No question found'
        return render_template('dashboard.html', msg = msg)


@app.route('/dashboard/ans_question/<string:id>', methods = ['GET','POST'])
@is_logged_in
def ans_question(id):
    question = dbQandA.questions.find({"_id":ObjectId(id)})
    form = AForm(request.form)
    if question:
        if request.method == 'POST' and form.validate():
            answer = form.answer.data
            answered_by = session['name']
            answer={
                "q_id":ObjectId(id),
                "answer":answer,
                "answered_by": answered_by,
                "answer_date": datetime.now()
            }
            dbResponse = dbQandA.answers.insert_one(answer)
            if dbResponse:
                flash('Your answer is posted', 'success')
                return redirect(url_for('dashboard'))
            else:
                flash('Something went wrong','danger')
                return render_template('ans_question.html', form = form, questions = question)

    return render_template('ans_question.html', form = form, questions = question)

@app.route('/dashboard/member_answers/<string:id>', methods = ['GET','POST'])
@is_logged_in
def member_answers(id):
    questions = dbQandA.questions.find({"_id":ObjectId(id)})
    answers = dbQandA.answers.find({"q_id":ObjectId(id)})
    if questions:
         return render_template('member_answers.html', questions = questions, answers = answers, id= id)
    else:
       return render_template('member_answers.html')


@app.route('/dashboard/re_answer/<string:id>', methods = ['GET','POST'])
@is_logged_in
def re_answer(id):
    answers = dbQandA.answers.find({"q_id":ObjectId(id)})
    form = AForm(request.form)
    if answers:
        if request.method == 'POST' and form.validate():
            answer = form.answer.data
            answered_by = session['name']
            answer={
                "q_id":ObjectId(id),
                "answer":answer,
                "answered_by": answered_by,
                "answer_date": datetime.now()
            }
            dbResponse = dbQandA.answers.insert_one(answer)
            if dbResponse:
                flash('Your answer is posted', 'success')
                return redirect(url_for('dashboard'))
            else:
                flash('Something went wrong','danger')
                return render_template('re_answer.html', form = form, answers = answers)

    return render_template('re_answer.html', form = form, answers = answers)

@app.route('/dashboard/edit_answer/<string:id>', methods = ['GET', 'POST'])
@is_logged_in
def edit_answer(id):
    answerData = dbQandA.answers.find({"_id":ObjectId(id)})
    form = AForm(request.form)
    if answerData:
        for ans in answerData:
            form.answer.data = ans['answer']
        if request.method == 'POST' and form.validate():
            answer = request.form['answer']
            dbResponse = dbQandA.answers.update_one(
                {"_id":ObjectId(id)},
                {"$set":{"answer":answer}},
            )
            if dbResponse:
                flash('Your answer is updated','success')
                return redirect(url_for('dashboard'))
            else:
                flash('Something went wrong')
                return redirect(url_for('dashboard'))
    return render_template('edit_answer.html', form = form)

@app.route('/dashboard/delete_answer/<string:id>', methods = ['GET','POST'])
@is_logged_in
def delete_answer(id):
    dbResponse = dbQandA.answers.delete_one({"_id":ObjectId(id)})
    if dbResponse:
        flash('Your answer is deleted', 'success')
        return redirect(url_for('dashboard'))
    else:
        flash('Something went wrong','danger')
        return redirect(url_for('dashboard'))

@app.route('/logout')
@is_logged_in
def logout():
    session.clear()
    flash('You are logged out', 'success')
    return redirect(url_for('login'))

if __name__ == "__main__":
    app.secret_key='sc12345'
    app.run()
