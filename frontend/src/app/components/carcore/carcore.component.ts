import { Component } from '@angular/core';
import { Car } from 'src/app/models/car.model';
import { CarcoreService } from 'src/app/services/carcore.service';

@Component({
  selector: 'app-carcore',
  templateUrl: './carcore.component.html',
  styleUrls: ['./carcore.component.css']
})
export class CarcoreComponent {

  cars: Car[] = []

  constructor(private carcoreService: CarcoreService) { }

  ngOnInit(): void {
    this.carcoreService.getModelsForMake()
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
