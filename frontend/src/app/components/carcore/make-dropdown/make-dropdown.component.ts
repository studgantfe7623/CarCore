import { Component } from '@angular/core';
import { Car } from 'src/app/models/car.model';
import { MakeDropdownService } from 'src/app/services/make-dropdown.service';

@Component({
  selector: 'app-make-dropdown',
  templateUrl: './make-dropdown.component.html',
  styleUrls: ['./make-dropdown.component.css']
})
export class MakeDropdownComponent {
  cars: Car[] = []
  selectedMake: string = '';


  constructor(private makeDropdownService: MakeDropdownService) { }

  ngOnInit(): void {
    this.makeDropdownService.getAllMakes()
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

  searchCars() {
    this.makeDropdownService.searchCars(this.selectedMake)
      .subscribe({
        next: (cars) => {
          console.log(cars)
        }
      });
  }
}
