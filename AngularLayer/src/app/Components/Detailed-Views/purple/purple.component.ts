import { Component, OnInit } from '@angular/core';
import { AddToCart } from 'src/app/Models/Add To Cart';
import { Product } from 'src/app/Models/Products';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-purple',
  templateUrl: './purple.component.html',
  styleUrls: ['./purple.component.css']
})
export class PurpleComponent implements OnInit {
  purple: Product | undefined;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  AddToCart(purple = {name: 'Purple Dye', amount: 100, color: 'Purple', price: 10})
  {
    this.AR.AddToCart(purple);
    }
}
