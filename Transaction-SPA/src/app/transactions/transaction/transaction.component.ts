import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { IType } from 'src/app/shared/models/Types';
import { TypesService } from 'src/app/shared/types.service';
import { TransactionService } from '../../shared/transaction.service';
import { MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.scss']
})
export class TransactionComponent implements OnInit {

  types: IType[];

  constructor(
    private fb: FormBuilder,
    public transactionService: TransactionService,
    private typesService: TypesService,
    public dialogRef: MatDialogRef<TransactionComponent>,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.loadTransactionTypes();
  }

  //#region SERVICES
  loadTransactionTypes(){
    this.typesService.getTypes().subscribe(response => {
      this.types = response;
    }, error => {
      console.log(error);
    });
  }

//#endregion



//#region DIALOG BUTTON FUNCTIONS
SaveTransaction(): void{

  const id = this.transactionService.transactionForm.value.id;
  if (!id || id === 0){
    this.transactionService.createTransaction(this.transactionService.transactionForm.value).subscribe(response => {
      this.toastr.success('Customer added successfully!');
    }, error => {
      this.toastr.error(error.message);
      console.log(error.message);
    }
    );
    this.transactionService.getTransactions().subscribe();

  }
  else {
    this.transactionService.updateTransaction(this.transactionService.transactionForm.value).subscribe(response => {
      this.toastr.success('Customer updated successfully');

       }, error => {
        this.toastr.error(error.message);
        console.log(error.message);
        }
    );
  }

  this.transactionService.transactionForm.reset();
  this.transactionService.initializeForm();
  this.closeDialog();
}

closeDialog(){
  this.transactionService.transactionForm.reset();
  this.transactionService.initializeForm();
  this.dialogRef.close();

}
//#endregion

}
