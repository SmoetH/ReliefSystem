ReliefSystem - Work Integrated Learning 3B (Task 2)

Module: Work Integrated Learning 3B (XISD6329w)

Qualification: Diploma in Information Technology in Software Development

Institution: The Independent Institute of Education (IIE)

📌 Project Overview

ReliefSystem is an integrated multi-tier software solution developed to assist non-governmental organizations (NGOs) and disaster management teams in coordinating relief projects, managing resources, tracking project statuses, and streamlining operational reporting.

The system consists of three interconnected projects:

ReliefSystem.API: ASP.NET Core Web API serving as the central backend service for data persistence, security, and controller endpoints.

ReliefSystem.Web: ASP.NET Core Web Portal used by administrative staff to monitor active relief initiatives and manage project records.

ReliefSystem.Mobile: .NET MAUI mobile client built for field operatives to view and submit real-time project updates.

⚙️ Technology Stack & Architecture

Framework: .NET 8.0

Backend: ASP.NET Core Web API (RESTful endpoints, Swagger/OpenAPI)

Web Frontend: ASP.NET Core MVC / Blazor

Mobile Frontend: .NET MAUI

Database: SQL Server / LocalDB (Entity Framework Core)

Version Control: Git & GitHub

🚀 Setup & Execution Guide

Prerequisites

Visual Studio 2022 (v17.8 or newer)

.NET 8.0 SDK

Required Visual Studio Workloads:

ASP.NET and web development

.NET Desktop Development

.NET Multi-platform App UI development (.NET MAUI)

Microsoft SQL Server Express or LocalDB

Installation & Local Setup

Clone the Repository:

git clone https://github.com/SmoetH/ReliefSystem.git
cd ReliefSystem


Database Configuration:

Open ReliefSystem.API/appsettings.json.

Update the DefaultConnection string to point to your local SQL Server instance.

Run EF Core migrations (if applicable):

dotnet ef database update --project ReliefSystem.API


Running the Solution:

Open ReliefSystem.sln in Visual Studio 2022.

Set ReliefSystem.API as a Startup Project and press F5 to start the backend services.

In a separate instance or multi-startup configuration, set ReliefSystem.Web as Startup Project to launch the administrative portal.

🎥 Video Demonstration

YouTube Video Link: https://youtube.com/@monaisatiisetso?si=zZkMk1DoYuWShL4w

Note: The video provides a walkthrough of the system architecture, API endpoints, web portal features, and database integration.

📄 Commit History & Progress

All developments, refactoring, and project setups have been tracked sequentially via Git commits to demonstrate compliance with the Software Development Life Cycle (SDLC) requirements for Task 2.
