import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { ITransactions } from './models/Transactions';
import { omit } from 'lodash';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {




constructor(private http: HttpClient) { }


  baseUrl = 'https://localhost:5001/api/';
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };




  //#region FORMS INITIALIZE, POPULATE AND SET
  transaction: ITransactions[] = [];

  transactionForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    firstName: new FormControl('', Validators.required),
    surname: new FormControl(''),
    email: new FormControl('',
    [ Validators.required,
      Validators.email,
      Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')
    ]),
    cellPhone: new FormControl('',
    [ Validators.required
     ]
    ),
    amountTotal: new FormControl(''),
    typeId: new FormControl()

  });
  //#endregion


//#region  HTTPServices

getTransactions(): Observable<ITransactions[]> {
  return this.http.get<ITransactions[]>(this.baseUrl + 'Transaction/ListTransactions');
}

createTransaction(transaction: ITransactions): Observable<ITransactions> {
  return this.http.post<ITransactions>(this.baseUrl + 'Transaction/AddTransaction', transaction, this.httpOptions);
}
updateTransaction(transaction: ITransactions): Observable<ITransactions> {
  return this.http.put<ITransactions>(this.baseUrl + 'Transaction/UpdateTransaction', transaction, this.httpOptions);
}

deleteTransaction(transactionId: number): Observable<number> {
  return this.http.delete<number>(this.baseUrl + 'Transaction/DeleteTransaction/' + transactionId, this.httpOptions);
}

  //#endregion

  initializeForm() {
    this.transactionForm.setValue({
      id: 0,
      firstName: '',
      surname: '',
      email: '',
      cellPhone: '',
      amountTotal: '',
      typeId: null
    });
    this.transactionForm.controls['cellPhone'].errors;
  }

  populateTransaction(transaction: ITransactions) {
    this.transactionForm.setValue(omit(transaction, 'type'));
  }

}
