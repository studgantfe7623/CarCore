import { Component } from '@angular/core';
import { Car } from 'src/app/models/car.model';
import { CarlistService } from 'src/app/services/carcore.service';

@Component({
  selector: 'app-carlist',
  templateUrl: './carlist.component.html',
  styleUrls: ['./carlist.component.css']
})
export class CarlistComponent {
  cars: Car[] = []

  constructor(private carlistService: CarlistService) { }

  ngOnInit(): void {
    this.carlistService.getModelsForMake()
      .subscribe({
        next: (cars) => {
          this.cars = cars;
          console.log(cars);
        },
        error: (response) => {
          console.log(response)
        }
      })
  }
}
