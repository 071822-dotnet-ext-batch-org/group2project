import { Component, OnInit } from '@angular/core';
import { AddToCart } from 'src/app/Models/Add To Cart';
import { Product } from 'src/app/Models/Products';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-orange',
  templateUrl: './orange.component.html',
  styleUrls: ['./orange.component.css']
})
export class OrangeComponent implements OnInit {
  orange: Product | undefined;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }
  
  AddToCart(orange = {name: 'Orange Dye', amount: 100, color: 'Orange', price: 10})
  {
    this.AR.AddToCart(orange);
    }

}
