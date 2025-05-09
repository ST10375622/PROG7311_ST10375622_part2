# Agri-Energy Connect

## Table of Contents

- [Overview](#overview)
- [Key Features](#key-features)
- [Challanges and changes](#challanges-and-changes)
- [Installation](#installation)
- [Build and Run](#build-and-run)
- [User Roles](#user-roles)
- [Youtube Link](Youtube-Link)

## Overview

Agri-Energy Connect is a visionary proposal that has been conceptualised in response to the growing need for sustainable agricultural practices and integration of green energy solutions in Soth Africa. It wants to develop a web platform that will fill the gap between the agricultural sector and green energy technology providers. 
The objective of this platform is to create a digital ecosystem where farmers, green energy experts, and enthusiasts can collaborate, share resources, and innovate in the spaces of sustainable agriculture and renewable energy.
The high-level plan for the Agri-Energy Connect Platform is fill the gap between the agricultural sector and the green energy technology providers. They want to create a platform where resources can be shared amongst each other. They want to create a platform where farmers can collaborate with green experts and have a place where they can get funding. A platform that will provide educational resources to the farmers and anyone who is interested in going into this sector. There will also be a marketplace. The high-level place is to provide a platform for everyone in the agricultural sector to make it.
Benefits of bridging sustainable agriculture with green energy solutions through a digital ecosystem is that there will be a platform that will provide help to anyone who needs it. There will be a platform that will connect everyone in the agricultural sector. There will be a place to find any resources that people in the agricultural sector require. 
I made use of the N-tier architecture pattern also known as layered architecture. In this architecture the different components of the platform are organised into separate layers of components The IIE 2018. the layers have specific roles in the platform. the different layers perform different things. the layers provide security and helped me when it came to restricting the farmer and or the employees from some features. It was also easy to make changes to my code when i had to make changes. the maintenance of this pattern is reletively easy. The N-Tier Architecture will be used. How I will integrate this pattern will be by defining the layers that I will be using in the project. The layers will be defined as the presentation layer, the Business logic layer, and the data access layer. The presentation layer will manage all the frontend aspect of the project which is what the user of the platform will see. The business logic will be where all the requests will be processed. The data access layer will manage all the backend of the project. It will manage all the databases interactions. I used MVC to create this website. It made it easy for me seperate the data. It was also easy for me as i knew that the models conected to the database and that the logic was in the controller and the presentation was in the views. This helped me understand which aspect needed to be fixed. For example, when there was an issue with the database then i knew i had to first check the models then the controller.
The Design pattern has the observer pattern. 
I made use of the SQL Server Database. The reason i picked this database is that i am ver familiar with it and i am able to work well with it. I used this database as it is able to handle real-time data and stores data nicely in a table format. It is relitively easier to make and changes to the database if required. 

## Key Features
- Sustainable Farming Hub
- Green Energy Marketplace
- Educational and training Resources
- Project Collaboration and funding Oppertunities

## Challanges and changes
1. I encountered some design issues when i was trying to make the the User Interface user friendly.
   - when i wanted to add a drop down for the location in the farmer profile. i encounterd some issues as the data was not being saved.
   - To fix this I remove the drop down and just put a hint to ensure that the Farmer/Employee are aware of what needs to be stored.
2. could not implement interactive section where farmers can collaborate.
   - I was not able to create the real-time chat for the farmers to come together with other farmers or employees to talk about businesses and gain funding
   - I made the chnage to just display Links to various websites for the farmers to go to
   - I also implemented an post section where is farmers require help they can post their issues and people can reply with comments. This will help the farmers to connect with other farmers.
   - With this Post feature the farmers can also just post about their experiences.

## Installation

1. **Clone the repository: <https://github.com/ST10375622/PROG7311_ST10375622_part2.git> **
2.  - Go to Visual Studio. (If you do not have it make sure that you install it)
    - Ensure that your visual studio is updated
     - Click on "Clone a repository"
     - You will then paste this link in Repository location
     - Then you will click on clone
3. Ensure that you have the following packages installed:
   - Microsoft.EntityFrameworkCore,
   - Microsoft.EntityFrameworkCore.SqlServer,
   -  Microsoft.EntityFrameworkCore.SqlServer.,
   -  Microsoft.EntityFrameworkCore.Tools
   -  Microsoft.visualstudio.web.codegeneration.design
   -  Microsoft.aspnetcore.identity.ui
   -  Microsoft.aspnetcore.identity.entityframeworkcore
   -  Microsoft.aspnetcore.diagnostics.entityframeworkcore
4. To Install these you will do the following
   - Go to the Tools tab
   - Look for nuGet Package Manager
   - Click on Manage NuGet Packages for solution
   - Then you ill go to Browse
   - Look for all the packages and install them.

## Build and Run
1. Clean the Build
 - Go to Build
 - Go to clean solution
2. Once that is done go to the Green play button and run the website (Ctrl + F5 for the shortcut)

## User Roles
1. The main users in this application are the Farmers and the Employees
2. The Farmers will be able to add product  to their profile.
3. The Employees will add new farmer profiles, view products from a specific farmer
4. The other functionalities and feaures can be seen by all the individuals.

## Youtube Link :
1. Link to the demo video: 

