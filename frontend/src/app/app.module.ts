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

import { EventsListComponent } from './pages/find/events-list/events-list.component';
import { EventComponent } from './pages/find/events-list/event/event.component';

import { FindComponent } from './pages/find/find.component';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { SignInComponent } from './auth/sign-in/sign-in.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AuthService } from './shared/services/auth.service';
import { AuthGuardService } from './shared/services/auth-guard.service';
import { SearchService } from './shared/services/search.service';
import { ApiService } from './shared/services/api.service';
import { PopularEventsComponent } from './components/popular-events/popular-events.component';
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
    PopularEventsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ApiService, AuthService, SearchService, AuthGuardService],
  bootstrap: [AppComponent]
})
export class AppModule {}
