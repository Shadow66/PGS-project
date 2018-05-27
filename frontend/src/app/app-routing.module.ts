import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { FindComponent } from './pages/find/find.component';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { SignInComponent } from './auth/sign-in/sign-in.component';
import { TestComponent } from './components/test/test.component';
import { AuthGuardService } from './shared/services/auth-guard.service';
import { EventDetailsComponent } from './pages/event-details/event-details.component';
import { CreateEventComponent } from './pages/create-event/create-event.component';
import { MyEventsComponent } from './pages/my-events/my-events.component';
import { EditEventComponent } from './pages/edit-event/edit-event.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'find',
    component: FindComponent
  },
  {
    path: 'find/:keyword',
    component: FindComponent
  },
  {
    path: 'signup',
    component: SignUpComponent
  },
  {
    path: 'signin',
    component: SignInComponent
  },
  {
    path: 'test',
    component: TestComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'event/:id',
    component: EventDetailsComponent
  },
  {
    path: 'create',
    component: CreateEventComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'edit/:id',
    component: EditEventComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'myevents',
    component: MyEventsComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
