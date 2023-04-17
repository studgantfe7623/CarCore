import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarlistComponent } from './components/carcore/carlist/carlist.component';

const routes: Routes = [
  {
    path: '',
    component: CarlistComponent
  }
  // {
  //   path: 'carcore',
  //   component: CarcoreComponent
  // }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
