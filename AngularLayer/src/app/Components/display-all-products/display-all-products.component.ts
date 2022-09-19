import { Component, NgModule, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service';


@Component({
  selector: 'app-display-all-products',
  templateUrl: './display-all-products.component.html',
  styleUrls: ['./display-all-products.component.css']
})
export class DisplayAllProductsComponent implements OnInit {

  allproducts: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  DisplayAllProducts()
  {
    this.AR.getAllProducts().then(data => {
      this.allproducts = data;
    })
  }

}
