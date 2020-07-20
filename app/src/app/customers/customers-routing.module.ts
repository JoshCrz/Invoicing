import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CustomersComponent } from './customers.component';

const routes: Routes = [
  { 
    path: '', component: CustomersComponent, children: [
      { path: '', redirectTo: 'list', pathMatch: 'full'}, 
      { path: 'list', loadChildren: () => import('./list/list.module').then(m => m.ListModule) }, 
      { path: 'create', loadChildren: () => import('./create/create.module').then(m => m.CreateModule) },
      { path: 'edit', loadChildren: () => import('./create/create.module').then(m => m.CreateModule) },
      { path: 'customer', loadChildren: () => import('./customer/customer.module').then(m => m.CustomerModule) },
      { path: 'delete', loadChildren: () => import('./delete/delete.module').then(m => m.DeleteModule) }
    ]
  }    
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersRoutingModule { }
