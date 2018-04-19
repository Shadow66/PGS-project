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
import { HttpModule } from '@angular/http';
import { SearchComponent } from './components/search/search.component';

import { EventsListComponent } from './pages/find/events-list/events-list.component';
import { EventComponent } from './pages/find/events-list/event/event.component';

import { FindComponent } from './pages/find/find.component';
import { SearchCommunicationService } from './shared/search-communication.service';


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
    FindComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule
  ],
  providers: [ApiService, SearchCommunicationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
