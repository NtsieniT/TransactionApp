import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MaterialModule } from './material/material.module'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { TypesService } from './shared/types.service';
import { TransactionService } from './shared/transaction.service';

import { ToastrModule } from 'ngx-toastr';
import { TransactionsComponent } from './transactions/transactions.component';
import { TransactionComponent } from './transactions/transaction/transaction.component';
import { TransactionListComponent } from './transactions/transaction-list/transaction-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TransactionComponent,
    TransactionsComponent,
    TransactionListComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
    
  ],
  providers: [
    TransactionService,
    TypesService
  ],
  bootstrap: [AppComponent],
  entryComponents: [TransactionsComponent]
})
export class AppModule { }
