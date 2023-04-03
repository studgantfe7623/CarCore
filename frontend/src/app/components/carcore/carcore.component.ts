import { Component } from '@angular/core';
import { Car } from 'src/app/models/car.model';

@Component({
  selector: 'app-carcore',
  templateUrl: './carcore.component.html',
  styleUrls: ['./carcore.component.css']
})
export class CarcoreComponent {

  cars: Car[] = []
  //   {
  //     id: '1',
  //     make: 'BMW',
  //     model: "750 iL"
  //   },
  //   {
  //     id: '2',
  //     make: 'BMW',
  //     model: "M2"
  //   },
  //   {
  //     id: '3',
  //     make: 'BMW',
  //     model: "340i"
  //   }
  // ];
  
  constructor() { }

  ngOnInit(): void {
    this.cars.push()
  }
}
