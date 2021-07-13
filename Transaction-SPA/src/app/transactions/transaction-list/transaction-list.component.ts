import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';

import { ITransactions} from 'src/app/shared/models/Transactions';
import { TransactionService } from '../../shared/transaction.service';
import { ToastrService } from 'ngx-toastr';

import { TransactionComponent } from '../transaction/transaction.component';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.scss']
})
export class TransactionListComponent implements OnInit {

  constructor(
    private transactionService: TransactionService,
    private dialog: MatDialog,
    private toastr: ToastrService
    ) { }


    transactionData: ITransactions[] = [];
    dataSource: MatTableDataSource<any>;

    displayedColumns: string[] = ['Firstname', 'Surname', 'Email', 'cellPhone', 'Invoice Total', 'Transaction Type', 'Action'];


  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  searchKey: string;

  dialogConfig = new MatDialogConfig();

  ngOnInit(){
    this.listTransactions();
  }

  onSearchClear() {
    this.searchKey = '';
    this.applyFilter();
  }

  applyFilter() {

    this.dataSource.filter = this.searchKey.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  listTransactions() {
    this.transactionService.getTransactions().subscribe(response => {
      this.transactionData = response;
      this.dataSource = new MatTableDataSource(this.transactionData);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    },
    error => {
      console.log(error);
    });

  }


  private refreshTable() {
    this.paginator._changePageSize(this.paginator.pageSize);
  }

  onCreate(){
    this.transactionService.initializeForm();
    this.dialogConfig.disableClose = true;
    this.dialogConfig.autoFocus = true;
    this.dialogConfig.width = '45%';
    this.dialog.open(TransactionComponent, this.dialogConfig);
    this.RefreshListOnDialogClose();
  }

  viewTransactionInfo(row: any){
    this.transactionService.populateTransaction(row);
    this.dialogConfig.disableClose = true;
    this.dialogConfig.width = '45%';
    this.dialog.open(TransactionComponent, this.dialogConfig);
    this.RefreshListOnDialogClose();

  }

  deleteTransactionInfo(id: number){
    if (confirm('Are you sure ?')) {
    this.transactionService.deleteTransaction(id).subscribe(response => {
      this.toastr.warning('Transaction successfully deleted!');
      this.listTransactions();
      this.refreshTable();
    }, error => {
      console.log(error.message);
    });
    }

  }
  // Configure dialog box here
  dialogConfigs(dialogConfigs: MatDialogConfig){
    dialogConfigs.disableClose = true;
    dialogConfigs.autoFocus = true;
    dialogConfigs.width = '45%';
    this.dialog.open(TransactionComponent, this.dialogConfig);
  }



  RefreshListOnDialogClose(){
    this.dialog.afterAllClosed.subscribe(() =>{
      this.listTransactions();
      this.refreshTable();
    })
  }



}
