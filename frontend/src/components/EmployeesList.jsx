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
  const [id, setId] = useState();

  const [first_name, setFirst_Name] = useState("");
  const [surname, setSurname] = useState("");
  const [email, setEmail] = useState("");
  const [phone_number, setPhone_number] = useState("");
  const [hire_date, setHire_date] = useState("");
  const [job_name, setJob_name] = useState("");
  const [salary, setSalary] = useState("");
  const [commission, setCommission] = useState("");
  const [manager, setManager] = useState("");
  const [department_name, setDepartment_name] = useState("");

  const formData = {
    id,
    first_name,
    surname,
    email,
    phone_number,
    hire_date,
    job_name,
    salary,
    commission,
    manager,
    department_name,
  };

  const [originalFormData, setOriginalFormData] = useState({
    first_name: "",
    surname: "",
    email: "",
    phone_number: "",
    hire_date: "",
    job_name: "",
    salary: "",
    commission: "",
    manager: "",
    department_name: "",
  });

  const handleEdit = (id) => {
    setId(id);
    const employee = data.find((emp) => emp.id === id);
    setOriginalFormData(employee);

    setFirst_Name(employee.first_name);
    setSurname(employee.surname);
    setEmail(employee.email);
    setPhone_number(employee.phone_number);
    setHire_date(employee.hire_date);
    setJob_name(employee.job_name);
    setSalary(employee.salary);
    setCommission(employee.commission);
    setManager(employee.manager);
    setDepartment_name(employee.department_name);
  };

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
      // const response = await fetch(
      //   "https://my.api.mockaroo.com/users.json?key=d9ffeed0"
      // );
      // if (!response.ok) {
      //   throw new Error('Network response was not ok');
      // }
      // const result = await response.json();
      setData(Dane);
      setTempData(Dane);
    } catch (error) {
      setError(error);
    } finally {
      setIsLoading(false);
    }
  };

  const deleteData = async (promp) => {
    try {
      console.log(promp);
      // const response = await fetch(
      //   "https://your-server-endpoint.com/api/endpoint", //wkleić tutaj endpoint do usuwania użytkownika
      //   {
      //     method: "POST",
      //     headers: { "Content-Type": "application/json" },
      //     body: JSON.stringify(promp),
      //   }
      // );
      // if (!response.ok) {
      //   throw new Error("Network response was not ok");
      // }
      // const result = await response.json();
      // console.log("Success:", result);
    } catch (e) {
      console.log(`Wystąpił błąd: ${e}`);
    }
  };

  const isEmpty = (obj) => {
    return Object.keys(obj).length === 0;
  };

  const editData = async () => {
    const differences = Object.fromEntries(
      Object.entries(formData).filter(
        ([key, value]) => value !== originalFormData[key]
      )
    );

    const result = { id: id, ...differences };

    try {
      if (!isEmpty(differences)) {
        console.log(JSON.stringify(result));
        // const response = await fetch(
        //   "https://your-server-endpoint.com/api/endpoint", //wkleić tutaj endpoint do edytowania użytkownika
        //   {
        //     method: "POST",
        //     headers: { "Content-Type": "application/json" },
        //     body: JSON.stringify(result),
        //   }
        // );
        // if (!response.ok) {
        //   throw new Error("Network response was not ok");
        // }
        // const result = await response.json();
        // console.log("Success:", result);
      }
    } catch (e) {
      console.log(`Wystąpił błąd: ${e}`);
    }

    setId(null);
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
              <th>
                Usuń/
                <br />
                Edytuj
              </th>
            </tr>
          </thead>
          <tbody>
            {data.map((employee, index) => (
              <tr key={index}>
                {id === employee.id ? (
                  <>
                    <td>
                      <input
                        defaultValue={employee.first_name}
                        onChange={(e) => {
                          {
                            setFirst_Name(e.target.value) &&
                              setFirst_Name(employee.first_name);
                          }
                        }}
                        className="editInput"
                        type="text"
                      />
                    </td>
                    <td>
                      <input
                        onChange={(e) => {
                          setSurname(e.target.value);
                        }}
                        defaultValue={employee.surname}
                        className="editInput"
                        type="text"
                      />
                    </td>
                    <td>
                      <input
                        onChange={(e) => {
                          setEmail(e.target.value);
                        }}
                        defaultValue={employee.email}
                        className="editInput"
                        type="email"
                      />
                    </td>
                    <td>
                      <input
                        onChange={(e) => {
                          setPhone_number(e.target.value);
                        }}
                        defaultValue={employee.phone_number}
                        className="editInput"
                        type="text"
                      />
                    </td>
                    <td>
                      <input
                        onChange={(e) => {
                          setHire_date(e.target.value);
                        }}
                        defaultValue={
                          new Date(employee.hire_date)
                            .toISOString()
                            .split("T")[0]
                        }
                        className="editInput"
                        type="date"
                      />
                    </td>
                    <td>
                      <input
                        onChange={(e) => {
                          setJob_name(e.target.value);
                        }}
                        defaultValue={employee.job_name}
                        className="editInput"
                        type="text"
                      />
                    </td>
                    <td>
                      <input
                        onChange={(e) => {
                          setSalary(e.target.value);
                        }}
                        defaultValue={employee.salary}
                        className="editInput"
                        type="number"
                      />
                    </td>
                    <td>
                      <input
                        onChange={(e) => {
                          setCommission(e.target.value);
                        }}
                        defaultValue={employee.commission}
                        className="editInput"
                        type="number"
                      />
                    </td>
                    <td>
                      <input
                        onChange={(e) => {
                          setManager(e.target.value);
                        }}
                        defaultValue={employee.manager}
                        className="editInput"
                        type="text"
                      />
                    </td>
                    <td>
                      <input
                        onChange={(e) => {
                          setDepartment_name(e.target.value);
                        }}
                        defaultValue={employee.department_name}
                        className="editInput"
                        type="text"
                      />
                    </td>
                    <td>
                      <button className="editUser" onClick={() => editData()}>
                        Zapisz
                      </button>
                      <button className="editUser" onClick={() => setId(null)}>
                        Anuluj
                      </button>
                    </td>
                  </>
                ) : (
                  <>
                    <td>{employee.first_name}</td>
                    <td>{employee.surname}</td>
                    <td>{employee.email}</td>
                    <td>{employee.phone_number}</td>
                    <td>
                      {new Date(employee.hire_date).toISOString().split("T")[0]}
                    </td>

                    <td>{employee.job_name}</td>
                    <td>{employee.salary}</td>
                    <td>{employee.commission}</td>
                    <td>{employee.manager}</td>
                    <td>{employee.department_name}</td>
                    <td>
                      <button
                        className="deleteUser"
                        onClick={() => {
                          deleteData(employee.id);
                        }}
                      >
                        Usuń
                      </button>
                      <button
                        className="editUser"
                        onClick={() => {
                          handleEdit(employee.id);
                        }}
                      >
                        Edytuj
                      </button>
                    </td>
                  </>
                )}
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
};
