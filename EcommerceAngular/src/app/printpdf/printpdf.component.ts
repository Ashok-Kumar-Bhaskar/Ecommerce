import { Component, OnInit } from '@angular/core';
import { Invoiceitems } from '../models/invoiceitems.model';
import jspdf from 'jspdf';  
import html2canvas from 'html2canvas'; 

@Component({
  selector: 'app-printpdf',
  templateUrl: './printpdf.component.html',
  styleUrls: ['./printpdf.component.css']
})
export class PrintpdfComponent implements OnInit {

  element : Invoiceitems = new Invoiceitems();
  displayedColumns = ['Sno', 'Product', 'Quantity', 'Amount', 'DeliveryDate'];
  constructor() { }

  ngOnInit(): void {
    this.element = JSON.parse(localStorage.getItem("invoice"));
    console.log(this.element);
  }

  public download()  
  {  
    var data = document.getElementById('contentToConvert');  
    html2canvas(data).then(canvas => {  
      // Few necessary setting options  
      var imgWidth = 208;   
      var pageHeight = 295;    
      var imgHeight = canvas.height * imgWidth / canvas.width;  
      var heightLeft = imgHeight;  
  
      const contentDataURL = canvas.toDataURL('image/png')  
      let pdf = new jspdf('p', 'mm', 'a4'); // A4 size page of PDF  
      var position = 0;  
      pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight)  
      pdf.save('invoice.pdf'); // Generated PDF   
    });  
  }  

}
