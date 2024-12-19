import { useState } from "react";

/* eslint-disable no-unused-vars */
export const ListCheck = (props) => {
  const [checkedItems, setCheckedItems] = useState([]);

  const [pressContries, setPressContries] = useState(false);

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
            <h3 onClick={()=> setPressContries(!pressContries)}>Countries</h3>
          </li>
          <li>
            <h3>Departments</h3>
          </li>
          <li>
            <h3>Jobs</h3>
          </li>
          <li>
            <h3>Locations</h3>
          </li>
          <li>
            <h3>Regions</h3>
          </li>
        </ul>
      </div>
      <div className="list">
        {pressContries && <div id="countries">
          <label>
            <input
              type="checkbox"
              value="canada"
              checked={checkedItems.includes("canada")}
              onChange={handleCheckboxChange}
            />
            Canada
          </label>
          <label>
            <input
              type="checkbox"
              value="germany"
              checked={checkedItems.includes("germany")}
              onChange={handleCheckboxChange}
            />
            Germany
          </label>
          <label>
            <input
              type="checkbox"
              value="UK"
              checked={checkedItems.includes("UK")}
              onChange={handleCheckboxChange}
            />
            United Kingdom
          </label>
          <label>
            <input
              type="checkbox"
              value="USA"
              checked={checkedItems.includes("USA")}
              onChange={handleCheckboxChange}
            />
            USA
          </label>
        </div>}
      </div>
    </form>
  );
};
