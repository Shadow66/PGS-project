import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { AppRoutingModule } from './/app-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { TestComponent } from './components/test/test.component';
import { HttpClientModule } from '@angular/common/http';
import { SearchComponent } from './components/search/search.component';

import { EventsListComponent } from './components/events-list/events-list.component';
import { EventComponent } from './components/event/event.component';

import { FindComponent } from './pages/find/find.component';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { SignInComponent } from './auth/sign-in/sign-in.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AuthService } from './shared/services/auth.service';
import { AuthGuardService } from './shared/services/auth-guard.service';
import { SearchService } from './shared/services/search.service';
import { PopularEventsComponent } from './components/popular-events/popular-events.component';
import { TestService } from './shared/services/test.service';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './shared/interceptors/token.interceptor';
import { ApiInterceptor } from './shared/interceptors/api.interceptor';
import { EventDetailsComponent } from './pages/event-details/event-details.component';
import { ParticipantsListComponent } from './components/participants-list/participants-list.component';
import { ParticipantComponent } from './components/participant/participant.component';
import { EventService } from './shared/services/event.service';
import { CreateEventComponent } from './pages/create-event/create-event.component';
import { CategoriesPipe } from './shared/pipes/category.pipe';
import { MyEventsComponent } from './pages/my-events/my-events.component';
import { MyEventsListComponent } from './components/my-events-list/my-events-list.component';
import { EditEventComponent } from './pages/edit-event/edit-event.component';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    TestComponent,
    SearchComponent,
    EventsListComponent,
    EventComponent,
    FindComponent,
    SignUpComponent,
    SignInComponent,
    PopularEventsComponent,
    EventDetailsComponent,
    ParticipantsListComponent,
    ParticipantComponent,
    CreateEventComponent,
    CategoriesPipe,
    MyEventsComponent,
    MyEventsListComponent,
    EditEventComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthService,
    SearchService,
    EventService,
    AuthGuardService,
    TestService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
