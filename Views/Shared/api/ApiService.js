class ShipmentType {

    static ShipmentType = new ShipmentType("Standard", 0);
    static ShipmentType = new ShipmentType("Live Animals", 1);
    // static ShipmentType = new ShipmentType("Dead animals", 2);
    static ShipmentType = new ShipmentType("Refrigerated", 3);
    // static ShipmentType = new ShipmentType("Children", 4);
    static ShipmentType = new ShipmentType("Cautious", 5);
    // static ShipmentType = new ShipmentType("Furniture", 6);
    // static ShipmentType = new ShipmentType("Weapons", 7);
    static ShipmentType = new ShipmentType("Recorded", 8);

    constructor(name, numericalValue) {
        this.name = name;
        this.numericalValue = numericalValue;
    }
}


function getRoutes(from, to, shipmentType, weight) {
    const request = new XMLHttpRequest();
    const url = `/api/1/routes/?from=${from}&to=${to}&type=${shipmentType.numericalValue}&weight=${weight}`;
    let response = {}

    request.open("GET", url, false);
    request.setRequestHeader("Content-Type", "application/json");
    request.onreadystatechange = function () {
        if (request.readyState == XMLHttpRequest.DONE) {
            if (request.status == 200)
                response = JSON.parse(request.responseText);
        }
    };
    return response;
}