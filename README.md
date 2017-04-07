# :spaghetti: RESTFull
A lightweight yet powerful REST API service for providing restaurant data for integrations.

## What is RESTFull

It's the current year of 2017 and it's about time we were able to integrate our restaurants into
our mobile apps, web apps and the Internet of Things.

RESTFull will provide a simple, flexible, API system that can be easily deployed cross-platform
and modifed to suit the needs of the client.

The system's backend is written ASP.NET Core MVC using the WebAPI system to provide a logical,
powerful and lightweight solution.

In the original release, RESTFull should provide endpoints for **all aspects of a restaurant's menu**, including specific functionality such as:

- Menu Pricing & Deals
- Nutritional values adhering to Australian requirements if necessary
- Filtering & Search functionality for the API

## Developers

- Tushar Bassi
    - Product Owner
    - Test Overseer
- Alex Billson
    - Head Programmer
    - Database Structure & Migrations
- Martin Lim
    - Head of Front-End Design
    - UI Designer
- Kevin Christopher
    - Backend Developer
    - Data Modelling
    
## Technical Details

- Backend
    - Based on .NET Core
    - Uses ASP.NET MVC 5's Web API setup
    - Utilizing Entity Framework for Database Migration and Connection
    - SQLite will be used as it allows for portability
- Frontend Example
    - HTML, CSS & JS obviously
    - Uses AngularJS and an MVVM based design
    - Bootstrap for UI? (Martin's decision)