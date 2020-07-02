
# Goal

to create a simple  extendable invoicing system


## What we are going to use

**front-end**

Angular v?? (JC's)

**back-end**

.net core 3.1

ef core 3.1


## Project structure

**Data Access**

* Entity Models
> Plain classes representing database table structure. No data annotations. Entity Models should represent the data as is in the database.
* Repository
> Generic application context no unity of work, as to early to think what's best. Entity Models configuration using fluent api.

**Business**

* Service
> Service will dictate the state and shape of data being passed to the api and front-end. Not sure what will go here at this moment tbh. Soon :)
* (to do) ViewModels
> Probably need view models to return to the front-end. Different models for write/update and details/list ? 

**Presentation**

* app
> Let's be honest, front end is only to look pretty and pretend to have a purpose. But maybe JC wanna remove this line, and add his own comment :) 
* WebApi
> 








