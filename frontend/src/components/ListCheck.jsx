import { useState } from "react";

/* eslint-disable no-unused-vars */
export const ListCheck = (props) => {
  const [checkedItems, setCheckedItems] = useState([]);
  const [pressCategory, setPressCategory] = useState(null);

  const data = {
    countries: ["Canada", "Germany", "UK", "USA"],
    departments: [
      "Administration",
      "Marketing",
      "Shipping",
      "IT",
      "Sales",
      "Executive",
      "Accounting",
      "Contacting",
    ],
    jobs: [
      "Administration",
      "Marketing",
      "Shipping",
      "IT",
      "Sales",
      "Executive",
      "Accounting",
      "Contacting",
    ],
  };

  const handleCheckboxChange = (event) => {
    const { value, checked } = event.target;
    setCheckedItems((prevCheckedItems) =>
      checked
        ? [...prevCheckedItems, value]
        : prevCheckedItems.filter((item) => item !== value)
    );
  };

  return (
    <form action="" id="listCheck">
      <div>
        <ul>
          <li>
            <h3
              onClick={() => {
                if (pressCategory === "countries") setPressCategory(null);
                else setPressCategory("countries");
              }}
            >
              Countries
            </h3>
          </li>
          <li>
            <h3
              onClick={() => {
                if (pressCategory === "departments") setPressCategory(null);
                else setPressCategory("departments");
              }}
            >
              Departments
            </h3>
          </li>
          <li>
            <h3>Jobs</h3>
          </li>
          <li>
            <h3>Locations</h3>
          </li>
        </ul>
      </div>
      <div className="list">
        <div>
          {pressCategory && (
            <div id={pressCategory}>
              {data[pressCategory].map((item) => (
                <label key={item}>
                  <input
                    type="checkbox"
                    value={item}
                    checked={checkedItems.includes(item)}
                    onChange={handleCheckboxChange}
                  />
                  {item}
                </label>
              ))}
            </div>
          )}
        </div>
      </div>
    </form>
  );
};
