import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';


@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

  createproduct: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  CreateProducts()
  {
    this.AR.postNewProduct(this.createproduct).then(data => {
      this.createproduct = data;
    })
  }
}
