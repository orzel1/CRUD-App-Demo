import { useState, useEffect } from "react";
import { Dane } from "./Dane";
import { HiArrowCircleUp } from "react-icons/hi";
import { HiArrowCircleDown } from "react-icons/hi";
import { Search } from "./Search";

/* eslint-disable no-unused-vars */
export const EmployeesList = (props) => {
  const [data, setData] = useState([]);
  const [tempData, setTempData] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);
  const [isReverse, setIsReverse] = useState(false);
  const [sorted, setSorted] = useState();

  const sortByString = (key) => {
    setSorted(key);
    const sortedData = [...data].sort((a, b) => {
      if (a[key] < b[key]) return -1;
      if (a[key] > b[key]) return 1;
      return 0;
    });
    if (isReverse) {
      sortedData.reverse();
      setIsReverse(false);
    } else {
      setIsReverse(true);
    }
    setData(sortedData);
  };

  const sortByNumber = (key) => {
    setSorted(key);
    const sortedData = [...data].sort((a, b) => a[key] - b[key]);
    if (isReverse) {
      sortedData.reverse();
      setIsReverse(false);
    } else {
      setIsReverse(true);
    }
    setData(sortedData);
  };

  const sortByDate = (key) => {
    setSorted(key);
    const sortedData = [...data].sort((a, b) => {
      return new Date(a[key]) - new Date(b[key]);
    });
    if (isReverse) {
      sortedData.reverse();
      setIsReverse(false);
    } else {
      setIsReverse(true);
    }
    setData(sortedData);
  };

  const search = (value) => {
    const matchedPhrase = tempData.filter((user) => {
      return `${user.first_name} ${user.surname}`
        .toLowerCase()
        .includes(value.toLowerCase());
    });
    setData(matchedPhrase);
  };

  const renderArrow = () => {
    if (!isReverse) return <HiArrowCircleDown className="arrow" />;
    else return <HiArrowCircleUp className="arrow" />;
  };
  const fetchData = async () => {
    try {
      const response = await fetch(
        "https://my.api.mockaroo.com/users.json?key=d9ffeed0"
      );
      // if (!response.ok) {
      //   throw new Error('Network response was not ok');
      // }
      const result = await response.json();
      setData(Dane);
      setTempData(Dane);
    } catch (error) {
      setError(error);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  return (
    <>
      <Search onSearchChange={search} />
      <div id="tableEmployee">
        <table>
          <thead>
            <tr>
              <th onClick={() => sortByString("first_name")}>
                Imię
                {sorted === "first_name" ? renderArrow() : null}
              </th>
              <th onClick={() => sortByString("surname")}>
                Nazwisko
                {sorted === "surname" ? renderArrow() : null}
              </th>
              <th onClick={() => sortByString("email")}>
                Email
                {sorted === "email" ? renderArrow() : null}
              </th>
              <th>Nr telefonu</th>
              <th onClick={() => sortByDate("hire_date")}>
                Data Zatrudnienia
                {sorted === "hire_date" ? renderArrow() : null}
              </th>
              <th onClick={() => sortByString("job_name")}>
                Nazwa Pracy
                {sorted === "job_name" ? renderArrow() : null}
              </th>
              <th onClick={() => sortByNumber("salary")}>
                Wynagrodzenie
                {sorted === "salary" ? renderArrow() : null}
              </th>
              <th onClick={() => sortByNumber("commission")}>
                Prowizja
                {sorted === "commission" ? renderArrow() : null}
              </th>
              <th onClick={() => sortByString("manager")}>
                Menadżer
                {sorted === "manager" ? renderArrow() : null}
              </th>
              <th onClick={() => sortByString("department_name")}>
                Nazwa Departamentu
                {sorted === "department_name" ? renderArrow() : null}
              </th>
              <th>Usuń</th>
            </tr>
          </thead>
          <tbody>
            {data.map((employee, index) => (
              <tr key={index}>
                <td>{employee.first_name}</td>
                <td>{employee.surname}</td>
                <td>{employee.email}</td>
                <td>{employee.phone_number}</td>
                <td>{employee.hire_date}</td>
                <td>{employee.job_name}</td>
                <td>{employee.salary}</td>
                <td>{employee.commission}</td>
                <td>{employee.manager}</td>
                <td>{employee.department_name}</td>
                <td>
                  <button className="deleteUser">Usuń</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
};
