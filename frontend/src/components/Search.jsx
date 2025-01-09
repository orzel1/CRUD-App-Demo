/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */

import { useState } from "react";

export const Search = ({ onSearchChange }) => {
  const [userPhrase, setUserPhrase] = useState("");

  const handlerChange = (event) => {
    setUserPhrase(event.target.value);
    onSearchChange(event.target.value);
  };

  console.log(userPhrase);
  return (
    <input
      type="text"
      name="searchEmployee"
      placeholder="Search employee"
      value={userPhrase}
      onChange={handlerChange}
    />
  );
};
