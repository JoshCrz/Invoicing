
# Goal

to create a simple  extendable invoicing system


## What we are going to use

**front-end**

>Angular v10

>Bootstrap v4

**back-end**

>.net core 3.1

>ef core 3.1


## Project structure

**Data Access**

* Entity Models
> Plain classes representing database table structure. No data annotations. Entity Models should represent the data as is in the database.
* Repository
> Generic application context no unity of work, as to early to think what's best. Entity Models configuration using fluent api.

**Business**

* Service
> Service will dictate the state and shape of data being passed to the api and front-end. Not sure what will go here at this moment tbh. Soon :)
> I will go with Command Pattenr for CRUD operations, and return view models from the api. Will do more googling over the new day or few and decide where ot go with this.
* ViewModels
> To be decided.

**Presentation**

* Architecture
>Lazy loaded and modularised design pattern

* Design
>Simple, clean and easy to use solution. Will be provided with animations; using Angular Animations Module. 

* Pre-packaged
>App will come packaged with ng-bootstrap, for easy to use modularised components (e.g ng-Modals).

* Unit Testing
> Unit testing framework to be decided

* Potential ideas
> Reactive form component, to be built on the fly based on users parameters. Could be passed via endpoint, model may look something like below

`
"response": {
  "formControls": [
    {
      "label": "first name",
      "type": 1, //text?
      "validators": [
        {
          "required": true
        }, 
        {
          "minLength": "60"
        }
      ]
    }
  ]
}
`

* WebApi
> 








