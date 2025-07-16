# Resource Booking System

A web application for managing resources and bookings.


## Project Structure

- **ResourceBookingSystemAPI** — Backend API project
- **ResourceBookingWeb** — Frontend web application


## Prerequisites

- .NET 6 SDK or later installed
- SQL Server LocalDB
- IDE (Visual Studio)

## How to Run

### 1. Run the Backend API

- Open the `ResourceBookingSystemAPI` project.
- Configure any necessary settings in `appsettings.json` (connection strings).
- Start the backend API project. This will launch the API on a specific URL (on Swagger).

### 2. Run the Frontend Web Application

- Open the `ResourceBookingWeb` project.
- Ensure the backend API URL in the frontend configuration matches the running backend URL.
- Start the frontend project.
- The frontend will interact with the backend API to manage resources and bookings.


## Usage
- You can create, view, edit, and delete resources and bookings.

## Notes

- Make sure the backend API is running before starting the frontend to avoid connection errors.
- If you face any issues with API connectivity, verify the backend URL configuration in the frontend project.






