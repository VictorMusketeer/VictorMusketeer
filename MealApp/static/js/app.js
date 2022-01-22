function checkOptions() {
    var sideDish = document.getElementsByName("sideDish");
    var dataDish = document.getElementById('dataSideDish');
    dataDish.value = '';
    var selectedOptionDish = '';
    for (i = 0; i < sideDish.length; i++) {
        if (sideDish[i].checked) {
            selectedOptionDish += sideDish[i].value + '#';
        }
    }
    dataDish.value = selectedOptionDish;

    var drink = document.getElementsByName("drink");
    var dataDrink = document.getElementById('dataDrink');
    dataDrink.value = '';
    var selectedOptionDrink = '';
    for (i = 0; i < drink.length; i++) {
        if (drink[i].checked) {
            selectedOptionDrink += drink[i].value + '#';
        }
    }
    dataDrink.value = selectedOptionDrink;

    var extra = document.getElementsByName("extra");
    var dataExtra = document.getElementById('dataExtra');
    dataExtra.value = '';
    var selectedOptionExtra = '';
    for (i = 0; i < extra.length; i++) {
        if (extra[i].checked) {
            selectedOptionExtra += extra[i].value + '#';
        }
    }
    dataExtra.value = selectedOptionExtra;
}