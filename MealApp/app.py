from enum import unique
from logging import debug
from math import fabs
from flask import Flask, render_template, flash, redirect, request, url_for, session
from datetime import datetime 
from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)

ENV = 'dev'
if ENV == 'dev':
    app.debug = True
    app.config['SQLALCHEMY_DATABASE_URI'] = 'postgresql://postgres:great100@localhost:3000/mealDB'
else:
    app.debug = False

app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
db = SQLAlchemy(app)

SEPARATOR = '#'

class Meal(db.Model):
    __tablename__ = 'orders'
    id = db.Column(db.Integer, primary_key =True)
    customer = db.Column(db.String(200), unique = True)
    chickenType = db.Column(db.String(200))
    flavour = db.Column(db.String(200))
    sideDish = db.Column(db.String(200))
    drink = db.Column(db.String(200))
    extra = db.Column(db.String(200))
    total_due = db.Column(db.Float)
    discount = db.Column(db.Float)
    order_date = db.Column(db.String)

    def __init__(self, orderData):
        self.customer = orderData['customerName']
        self.chickenType = orderData['chickenType']
        self.flavour = orderData['flavor']
        self.sideDish = orderData['sideDish']
        self.drink = orderData['drink']
        self.extra = orderData['extra']
        self.total_due = orderData['totalDue']
        self.discount = orderData['discount']
        self.order_date = datetime.now()

@app.route('/')
def index():
    return render_template('index.html')

def calculateTotal(orderData):
    #CHICKEN TYPE CONSTANTS
    QUARTER_CHICKEN = 15.00
    TWO_CHICKEN_BREASTS = 30.00
    FIVE_CHICKEN_WINGS  = 35.00
    CHICKEN_LIVERS = 25.00
    #SIDE DISH CONSTANTS
    CHIPS = 19.00
    FLAME_GRILLED_MEALI = 12.00
    PERI_PERI_WEDGES = 19.00
    SPICY_RICE = 34.00
    #DRINKS CONSTANTS
    COCA_COLA = 13.00
    ICED_TEA = 14.50
    LIQUI_FRUIT = 18.00
    WATER = 10.00
    #EXTRAS CONSTANTS
    FRESH_PORTUGUESE_ROLL = 3.95
    PORTUGUESE_SALAD = 19.95
    VANILLA_ICE_CREAM = 15.00
    CHOCOLATE_CAKE = 19.00

    totalDue = 0.00

    if orderData['chickenType'] == '1/4 Chicken':
        totalDue += QUARTER_CHICKEN
    elif orderData['chickenType'] == '2 Chicken Breasts':
        totalDue += TWO_CHICKEN_BREASTS
    elif orderData['chickenType'] == '5 Chicken Wings':
        totalDue += FIVE_CHICKEN_WINGS
    elif orderData['chickenType'] == 'Chicken Livers':
        totalDue += CHICKEN_LIVERS

    for side in orderData['sideDish']:
        if side == 'Chips':
            totalDue += CHIPS
        elif side == 'Flame Grilled Meali':
            totalDue += FLAME_GRILLED_MEALI
        elif side == 'Peri-Peri Wedges':
            totalDue += PERI_PERI_WEDGES
        elif side == 'Spicy Rice':
            totalDue += SPICY_RICE

    for side in orderData['drink']:
        if side == 'Coca-Cola':
            totalDue += COCA_COLA
        elif side == 'Iced Tea':
            totalDue += ICED_TEA
        elif side == 'Liqui Fruit':
            totalDue += LIQUI_FRUIT
        elif side == 'Water':
            totalDue += WATER

    for side in orderData['extra']:
        if side == 'Fresh Portuguese Roll':
            totalDue += FRESH_PORTUGUESE_ROLL
        elif side == 'Portuguese Salad':
            totalDue += PORTUGUESE_SALAD
        elif side == 'Vanilla Ice Cream':
            totalDue += VANILLA_ICE_CREAM
        elif side == 'Chocolate Cake':
            totalDue += CHOCOLATE_CAKE

    discount = 0.00
    if totalDue > 80:
        discount = totalDue * 0.2
        totalDue = totalDue -discount
    orderData['discount'] = discount
    orderData['totalDue'] = totalDue
    return orderData


@app.route('/order', methods= ['GET','POST'])
def order():
    
    if request.method == 'POST':
        pass
        customerName = request.form['customerName']
        chickenType = request.form['chickenType']
        flavor = request.form['flavor']
        sideDish = request.form['dataSideDish']
        drink = request.form['dataDrink']
        extra = request.form['dataExtra']

        sideObject =[]
        sideObject = sideDish.split('#')
        sideObject = sideObject[:-1]

        drinkObject =[]
        drinkObject = drink.split('#')
        drinkObject = drinkObject[:-1]

        extraObject =[]
        extraObject = extra.split('#')
        extraObject = extraObject[:-1]

        orderDetails = {"customerName":customerName, "chickenType":chickenType, "flavor":flavor, "sideDish":sideObject, "drink":drinkObject, "extra":extraObject} 
        total = calculateTotal(orderDetails)
        data = Meal(total)
        db.session.add(data)
        db.session.commit()
        order_number = 'J4F'+ orderDetails['customerName']
        total['order_number'] = order_number
        return render_template('receipt.html', total = total)
    return render_template('receipt.html')

if __name__ == "__main__":
    app.secret_key = 'secret12345'
    app.run()
