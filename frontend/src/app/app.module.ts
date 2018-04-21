import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { AppRoutingModule } from './/app-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { ApiService } from './shared/api.service';
import { TestComponent } from './components/test/test.component';
import { HttpClientModule } from '@angular/common/http';
import { SearchComponent } from './components/search/search.component';

import { EventsListComponent } from './pages/find/events-list/events-list.component';
import { EventComponent } from './pages/find/events-list/event/event.component';

import { FindComponent } from './pages/find/find.component';
import { SearchCommunicationService } from './shared/search-communication.service';
import { SignupComponent } from './auth/signup/signup.component';
import { SigninComponent } from './auth/signin/signin.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './auth/auth.service';
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
    SignupComponent,
    SigninComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ApiService, SearchCommunicationService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule {}
