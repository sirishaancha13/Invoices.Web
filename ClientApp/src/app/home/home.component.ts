import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  invoices: Invoice[];
  isFetchingData: boolean = false;
  healthStatus: boolean = false;
  totalOutstandingAmount: number = 0;
  totalAmount: number = 0;
  displayedColumns: string[] = ['customerName', 'issueDate', 'amount', 'outstandingAmount'];
  private baseUrl: string;
  private http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  public getXeroData() {
    this.isFetchingData = true;
    this.http.get<DataAnalysisReport>(this.baseUrl + 'api/Invoice/GetInvoices').subscribe(result => {
      this.invoices = result.invoices;
      this.healthStatus = result.healthStatus;
      this.totalOutstandingAmount = result.totalOutstandingAmount;
      this.totalAmount = result.totalAmount;
      this.isFetchingData = false;
    }, error => console.error(error))
  }
}

interface DataAnalysisReport {
  invoices: Invoice[];
  healthStatus: boolean;
  totalOutstandingAmount: number;
  totalAmount: number;
}

interface Invoice {
  customerName: string;
  issueDate: string;
  amount: number;
  outstandingAmount: number;
  isIssueDateOld: boolean;
}
