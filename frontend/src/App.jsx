/* eslint-disable no-unused-vars */
//import './App.css'
import { useState } from "react";
import { useSpring, animated } from "@react-spring/web";
import { Search } from "./components/Search";
import { EmployeesList } from "./components/EmployeesList";
import { ListCheck } from "./components/ListCheck";
import { Form } from "./components/Form";

function App() {
  const [press, setPress] = useState(true);

  const animatedHr = useSpring({
    transform: press ? "translate3d(0px,0px,0)" : "translate3d(180px,0px,0)",
    config: { duration: 200 },
  });

  const buttonSearch = (
    <h2 className="h2Button" onClick={() => setPress(true)}>
      Search Employee
      {<animated.hr style={animatedHr} id="hr1" />}
    </h2>
  );
  const buttonAdd = (
    <h2 className="h2Button" onClick={() => setPress(false)}>
      Add Employee {<animated.hr style={animatedHr} id="hr2" />}
    </h2>
  );

  return (
    <div id="container">
      <aside>
        <div id="menuLogo">
          <h3>SqlSystem Ziibd</h3>
          <img src="./src/img/oracle.png" alt="Oracle icon" id="oracleIcon" />
        </div>
        <ListCheck />
      </aside>
      <main>
        <h1>Employee Management System</h1>
        <hr />
        {buttonSearch}
        {buttonAdd}
        <hr />
        {press && (
          <>
            <Search />
            <EmployeesList />
          </>
        )}
        {!press && <><Form/></>}
      </main>
    </div>
  );
}

export default App;
