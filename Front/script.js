var serverResponse = document.querySelector('#response')


//GetAll function
function GetAllCoffee(){

  //create GET method
  const xhr = new XMLHttpRequest();
  xhr.open('GET', 'https://localhost:5001/api/coffee', true);
  xhr.setRequestHeader("Content-Type", "application/json");
  xhr.setRequestHeader('Accept', 'application/json');
  xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
  xhr.send();

  xhr.onreadystatechange = function() {
  if (xhr.readyState != 4) {
      return
  }

  if (xhr.status === 200) {
      var res = JSON.parse(xhr.responseText);

      main(res);
      console.log('result', JSON.parse(xhr.responseText))
  }else {
      console.log('error', xhr.responseText)
  }
  }   
}

//Create table function
 function addCell(tr, val) {
    var td = document.createElement('td');

    td.innerHTML = val;

    tr.appendChild(td)
  }

  function addRow(tbl, val_1, val_2, val_3) {
    var tr = document.createElement('tr');
    
    addCell(tr, val_1);
    addCell(tr, val_2);
    addCell(tr, val_3);

    tbl.appendChild(tr)
    addRowHandlers();
  }

  function main(array) {
    tbl = document.getElementById('tbl');

    var rows=array.length;

    for(var i =0; i<rows; i++)
    {
        addRow(tbl, array[i].name, array[i].price, array[i].type);
    }
  }

  // Delete table element
   function addRowHandlers() {
     var table = document.getElementById("tbl");
     var rows = table.getElementsByTagName("tr");
     for (i = 0; i < rows.length; i++) {
       var currentRow = table.rows[i];
       var createClickHandler = function(row) {
         return function() {
           // delete function
           var cell = row.getElementsByTagName("td")[0];
           var coffeeName = cell.innerHTML;
           let toDelete = confirm("Are you shure, you want to delete this coffee?");
           if(toDelete)
           {
              DeleteCoffeeByName(coffeeName);
              location.reload();
           }
         };
       };
       currentRow.onclick = createClickHandler(currentRow);
     }
   }


//Post(Add new coffee) function
function AddNewCoffee(){
 //create json
  const toSend = {
  name: document.getElementById("name").value,
  price: Number(document.getElementById("price").value),
  type: document.getElementById("type").value
 };
 const jsonString = JSON.stringify(toSend);

 //create POST method
  const xhr = new XMLHttpRequest();
  xhr.open("POST", "https://localhost:5001/api/coffee");
  xhr.setRequestHeader("Content-Type", "application/json");
  xhr.setRequestHeader('Accept', 'application/json');
  xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
  xhr.send(jsonString);
}


//Delete(delete coffe by name) function
function DeleteCoffeeByName(name){
  //create DELETE method
  const xhr = new XMLHttpRequest();
  var path = 'https://localhost:5001/api/coffee/' + name;
  xhr.open('DELETE', path, true);
  xhr.setRequestHeader("Content-Type", "application/json");
  xhr.setRequestHeader('Accept', 'application/json');
  xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
  xhr.send();

  xhr.onreadystatechange = function() {
  if (xhr.readyState != 4) {
      return
  }
  }   
 }