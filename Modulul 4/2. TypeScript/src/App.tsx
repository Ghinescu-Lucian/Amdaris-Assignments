import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Greeter } from './Classes/Greeter';
import { GenericType } from './Classes/Generic';

function App() {
  let generic1 = new GenericType<number>();
  generic1.zeroValue=0;
  generic1.add = function(x,y){ return x+y;};
  generic1.sub = function(x,y){ return x-y;};
 
  let generic2 = new GenericType<string>();
  generic2.zeroValue="";
  generic2.add = function(x,y){ return x+" "+y;};
  
  let result1 =generic2.add("Ana","are mere!");
  let result2 =generic1.sub(1,5);
  console.log(result1);
  console.log(result2);

  let userArrow = {
    username : "Admin",
    password : "1234321",
    authenticate: function(thePassword:string){
        return () =>
        {
           console.log(this);
          console.log(thePassword);

            let ok : boolean ;
            ok = false;
            if( this.password === thePassword)
                ok = true;
            console.log(ok);
        }
    }
}

let user = userArrow.authenticate("1234321");
user();

  let greeter = new Greeter("Admin!");
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h1>{greeter.greet()}</h1>
        <h2>
          Welcome to Ghini-Bikes!<br>
          </br>
          I love bikes.
Every passionate should know about     it    </h2>

      </header>
    </div>
  );
}

export default App;
