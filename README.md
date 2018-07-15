# Hair Salon

#### Epicodus C# Week 3 Independent Project, 7.15.18

#### Ryan Murry

## Description

A hair salon app that lets the user track stylist and clients.

## User Stories

* As a salon employee, I need to be able to see a list of all our stylists.
* As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As an employee, I need to add new stylists to our system when they are hired.
* As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.
* As an employee, I need to be able to update and delete individual and all stylists.
* As an employee, I need to be able to update and delete individual and all clients.
* As an employee, I need to be able to select which Stylists a Client belongs to.
* As an employee, I need to be able to select a client and see their details.

## Setup on OSX
* Download and install .Net Core 1.1.4
* Download and install Mono
* Download and install MAMP 4.5
* Clone the repo
* Open MAMP and start servers
* On the MAMP website, go to Tools > phpMyAdmid and import the database file `ryan_murry.sql`.
* Alternatively, open terminal and run the following commands
    * > `/Applications/MAMP/Library/bin/mysql --host=localhost -uroot -proot`
    * > `CREATE DATABASE ryan_murry`;
    * > `USE ryan_murry`;
    * > `CREATE TABLE clients (id serial PRIMARY KEY, stylist_id INT, first_name VARCHAR(255), last_name VARCHAR(255), phone_number VARCHAR(255), email VARCHAR(255), notes VARCHAR(255));`
    * > `CREATE TABLE stylists (id serial PRIMARY KEY, first_name VARCHAR(255), last_name VARCHAR(255), phone_number VARCHAR(255), email VARCHAR(255), street VARCHAR(255), city VARCHAR(255), state VARCHAR(255), zip VARCHAR(255), start_date));`
* On the MAMP website, go to Tools > phpMyAdmid and import the database file `ryan_murry_test.sql`.
* Alternatively, open terminal and run the following commands
    * > `/Applications/MAMP/Library/bin/mysql --host=localhost -uroot -proot`
    * > `CREATE DATABASE ryan_murry`;
    * > `USE ryan_murry`;
    * > `CREATE TABLE clients (id serial PRIMARY KEY, stylist_id INT, first_name VARCHAR(255), last_name VARCHAR(255), phone_number VARCHAR(255), email VARCHAR(255), notes VARCHAR(255));`
    * > `CREATE TABLE stylists (id serial PRIMARY KEY, first_name VARCHAR(255), last_name VARCHAR(255), phone_number VARCHAR(255), email VARCHAR(255), street VARCHAR(255), city VARCHAR(255), state VARCHAR(255), zip VARCHAR(255), start_date));`
* Run `dotnet restore` from project directory and test directory to install packages
* Run `dotnet build` from project directory and fix any build errors
* Run `dotnet test` from the test directory to run the testing suite
* Run `dotnet run` to run application

## Contribution Requirements

1. Clone the repo
1. Make a new branch
1. Commit and push your changes
1. Create a PR

## Technologies Used

* .Net Core 1.1.4
* MAMP 4.5
* MySql
* Bootstrap 3.3.7

## Links

* [Github Repo] (https://github.com/ryanjmurry/hair-salon)

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Ryan Murry**
