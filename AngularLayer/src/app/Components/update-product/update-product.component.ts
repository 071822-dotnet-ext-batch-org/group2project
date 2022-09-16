import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';


@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {

  updateproduct: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  UpdateProduct()
  {
    this.AR.putUpdateProduct(this.updateproduct).then(data => {
      this.updateproduct = data;
    })
  }
}
