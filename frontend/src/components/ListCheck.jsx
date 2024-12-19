import { useState } from "react";

/* eslint-disable no-unused-vars */
export const ListCheck = (props) => {
  const [checkedItems, setCheckedItems] = useState([]);

  const handleCheckboxChange = (event) => {
    const { value, checked } = event.target;
    setCheckedItems((prevCheckedItems) =>
      checked
        ? [...prevCheckedItems, value]
        : prevCheckedItems.filter((item) => item !== value)
    );
  };

  

  return (
    <form action="">
      <ul>
        <li>Countries</li>
        <li>Departments</li>
        <li>Employees</li>
        <li>Jobs</li>
        <li>Locations</li>
        <li>Regions</li>
      </ul>
    </form>
  );
};
