/* eslint-disable no-unused-vars */
import { useState } from "react";

export const Form = (props) => {
  const [canSend, setCanSend] = useState(true);

  const [vFirstName, setvFirstName] = useState("");
  const [vLastName, setvLastName] = useState("");
  const [vEmail, setvEmail] = useState("");
  const [vPhoneNumber, setvPhoneNumber] = useState("");
  const [vHireDate, setvHireDate] = useState("");
  const [vJobName, setvJobName] = useState("");
  const [vSalary, setvSalary] = useState("");
  const [vCommissionPCT, setvCommissionPCT] = useState("");
  const [vManager, setvManager] = useState("");
  const [vDepartmentName, setvDepartmentName] = useState("");

  const onSubmitFunction = async (event) => {
    {
      event.preventDefault();

      const formData = {
        vFirstName,
        vLastName,
        vEmail,
        vPhoneNumber,
        vHireDate,
        vJobName,
        vSalary,
        vCommissionPCT,
        vManager,
        vDepartmentName,
      };

      try {
        const response = await fetch(
          "https://your-server-endpoint.com/api/endpoint",
          {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(formData),
          }
        );
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        const result = await response.json();
        console.log("Success:", result);
      } catch (error) {
        console.error("Error:", error);
      }
    }
  };

  return (
    <form action="" onSubmit={onSubmitFunction}>
      <div id="addUser">
        Imie:
        <input
          type="text"
          onChange={(e) => setvFirstName(e.target.value)}
          name="firstName"
          placeholder="First Name"
        />
        Nazwisko:
        <input
          type="text"
          onChange={(e) => setvLastName(e.target.value)}
          name="lastName"
          placeholder="Last Name"
        />
        Email:
        <input
          type="email"
          onChange={(e) => setvEmail(e.target.value)}
          name="email"
          placeholder="Email"
        />
        Nr telefonu:
        <input
          type="text"
          onChange={(e) => setvPhoneNumber(e.target.value)}
          name="phoneNumber"
          placeholder="Phone Number"
        />
        Data Zatrudnienia:
        <input
          type="date"
          onChange={(e) => setvHireDate(e.target.value)}
          name="hireDate"
          placeholder="Hire Date"
        />
        Nazwa Pracy:
        <input
          type="text"
          onChange={(e) => setvJobName(e.target.value)}
          name="jobName"
          placeholder="Job Name"
        />
        Wynagrodzenie:
        <input
          type="number"
          onChange={(e) => setvSalary(e.target.value)}
          name="salary"
          placeholder="Salary"
        />
        Prowizja:
        <input
          type="number"
          onChange={(e) => setvCommissionPCT(e.target.value)}
          name="commissionPCT"
          placeholder="Commission PCT"
        />
        Menadżer:
        <input
          type="text"
          onChange={(e) => setvManager(e.target.value)}
          name="manager"
          placeholder="Manager"
        />
        Nazwa Departamentu:
        <input
          type="text"
          onChange={(e) => setvDepartmentName(e.target.value)}
          name="departmentName"
          placeholder="Department Name"
        />
        <button
          disabled={
            vLastName.length === 0 ||
            vEmail.length === 0 ||
            vHireDate.length === 0 ||
            vJobName.length === 0
          }
        >
          Dodaj
        </button>
      </div>
    </form>
  );
};
