import { Component, OnInit } from '@angular/core';
import { AddToCart } from 'src/app/Models/Add To Cart';
import { Product } from 'src/app/Models/Products';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-red',
  templateUrl: './red.component.html',
  styleUrls: ['./red.component.css']
})
export class RedComponent implements OnInit {
  red: Product | undefined;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  AddToCart(red = {name: 'Red Dye', amount: 100, color: 'Red', price: 10})
  {
    this.AR.AddToCart(red);
    }
}
