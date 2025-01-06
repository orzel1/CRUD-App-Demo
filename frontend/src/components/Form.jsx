/* eslint-disable no-unused-vars */
import { useState } from "react";

export const Form = (props) => {
  const [canSend, setCanSend] = useState(true);

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

  const onSubmitFunction = async (event) => {
    {
      event.preventDefault();

      const formData = {
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

      console.log(JSON.stringify(formData))

      // try {
      //   const response = await fetch(
      //     "https://your-server-endpoint.com/api/endpoint",
      //     {
      //       method: "POST",
      //       headers: { "Content-Type": "application/json" },
      //       body: JSON.stringify(formData),
      //     }
      //   );
      //   // if (!response.ok) {
      //   //   throw new Error("Network response was not ok");
      //   // }
      //   const result = await response.json();
      //   console.log("Success:", result);
      // } catch (error) {
      //   console.error("Error:", error);
      // }
    }
  };

  return (
    <form action="" onSubmit={onSubmitFunction}>
      <div id="addUser">
        Imie:
        <input
          type="text"
          onChange={(e) => setFirst_Name(e.target.value)}
          name="first_name"
          placeholder="First Name"
        />
        Nazwisko:
        <input
          type="text"
          onChange={(e) => setSurname(e.target.value)}
          name="surname"
          placeholder="Last Name"
        />
        Email:
        <input
          type="email"
          onChange={(e) => setEmail(e.target.value)}
          name="email"
          placeholder="Email"
        />
        Nr telefonu:
        <input
          type="text"
          onChange={(e) => setSalary(e.target.value)}
          name="phone_number"
          placeholder="Phone Number"
        />
        Data Zatrudnienia:
        <input
          type="date"
          onChange={(e) => setHire_date(e.target.value)}
          name="hire_date"
          placeholder="Hire Date"
        />
        Nazwa Pracy:
        <input
          type="text"
          onChange={(e) => setJob_name(e.target.value)}
          name="job_name"
          placeholder="Job Name"
        />
        Wynagrodzenie:
        <input
          type="number"
          onChange={(e) => setSalary(e.target.value)}
          name="salary"
          placeholder="Salary"
        />
        Prowizja:
        <input
          type="number"
          onChange={(e) => setCommission(e.target.value)}
          name="commission"
          placeholder="Commission PCT"
        />
        Menadżer:
        <input
          type="text"
          onChange={(e) => setManager(e.target.value)}
          name="manager"
          placeholder="Manager"
        />
        Nazwa Departamentu:
        <input
          type="text"
          onChange={(e) => setDepartment_name(e.target.value)}
          name="department_name"
          placeholder="Department Name"
        />
        <button
          disabled={
            surname.length === 0 ||
            email.length === 0 ||
            hire_date.length === 0 ||
            job_name.length === 0
          }
        >
          Dodaj
        </button>
      </div>
    </form>
  );
};
