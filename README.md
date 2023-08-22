# Senior Care Home | ASP.NET CORE MVC

### BCIT CST COMP 4945 Class Project
<img width="1339" alt="Screenshot 2023-08-21 at 5 15 08 PM" src="https://github.com/sehyun-kelly/CSharp-dotnetMVC-CareManagement/assets/89621420/a1a6b673-f0c4-46ba-be4c-6e8c0f3b4853">

## Project Description
This is a web application designed for managing senior care homes:

- **Admin Users**: They have full access to the system, manage account information, and input new service schedules as requested.
- **Managers**:
  - Oversee employee details, including salaries, vacations, qualifications, and shifts.
  - Monitor the rental statuses of residents.
  - Manage assets and appliances within the facility.
- **Employees**: They can view their weekly shifts and any scheduled services they are assigned to perform.

## Built With
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Bootstrap](https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white)


## Implementation
This project was a collaborative effort of everyone in the COMP 4945 course.

The class was divided into three teams: `Service Schedule`, `Organization Management`, and `Customer Relation Management`. I was a member of the Service Schedule team, and below are the features that I implemented.

### Manage Service Schedules
When a customer submits a new service request—with specified date, time, and service type—the admin user is tasked with creating a new schedule, taking into account employee shifts and existing schedules.

<img width="1282" alt="Screenshot 2023-08-21 at 5 01 43 PM" src="https://github.com/sehyun-kelly/CSharp-dotnetMVC-CareManagement/assets/89621420/28f644e9-57f7-41a2-b913-e37ac6797a08">

<img width="1285" alt="Screenshot 2023-08-21 at 5 02 17 PM" src="https://github.com/sehyun-kelly/CSharp-dotnetMVC-CareManagement/assets/89621420/c90c9f55-a7e7-4722-965b-284dadfb1889">

Once the fields for `Renter`, `Service Type`, `Start Time`, `End Time`, and `Repeat Information` are completed, a dropdown list will populate with the names of employees available to provide the requested service at the specified time and date.

### View Shift Schedules
Once logged in, employees should be able to check their weekly shifts and schedules.

<img width="1497" alt="Screenshot 2023-08-21 at 6 20 42 PM" src="https://github.com/sehyun-kelly/CSharp-dotnetMVC-CareManagement/assets/89621420/859c9c8b-ae1a-4387-8990-6eadf626ca0e">

<img width="1500" alt="Screenshot 2023-08-21 at 6 20 22 PM" src="https://github.com/sehyun-kelly/CSharp-dotnetMVC-CareManagement/assets/89621420/6ad9e465-686d-44d3-b846-efbfa5b1ffaf">

## Contact

Kelly Park 
- sehyun.kelly.park@gmail.com
- https://www.linkedin.com/in/sehyun-kelly-park/


