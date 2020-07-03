
# Goal

to create a simple  extendable invoicing system


## What we are going to use

**front-end**

Angular v10
Bootstrap v4

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
Lazy loaded and modularised architecture.
Simple, clean and easy to use solution. Will be provided with animations; using Angular Animations Module. App will come packaged with ng-bootstrap, for easy to use modularised components.

* WebApi
> 








