import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InvoicesComponent } from './invoices.component';

const routes: Routes = [
  {
    path: '', component: InvoicesComponent, children: [
      { path: '', redirectTo: 'list', pathMatch: 'full'},
      { path: 'list', loadChildren: () => import('./list/list.module').then(m => m.ListModule) },
      { path: 'invoice',  loadChildren: () => import('./invoice/invoice.module').then(m => m.InvoiceModule) },
      { path: 'create', loadChildren: () => import('./create/create.module').then(m => m.CreateModule) }
    ]    
  }  
]
 

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoicesRoutingModule { }
