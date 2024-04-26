import { Component } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormGroup, FormControl } from '@angular/forms';
import { UserDetail } from '../../models/user-detail';

@Component({
  selector: 'app-detail',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.scss'
})
export class DetailComponent {
  user?: User
  userId?: number
  imagePath?: string

  profileForm = new FormGroup({
    id: new FormControl(),
    title: new FormControl(),
    name: new FormControl(),
    email: new FormControl(),
    birthDate: new FormControl(),
    phone: new FormControl(),
    cell: new FormControl(),
    documentType: new FormControl(),
    documentValue: new FormControl(),
    postCode: new FormControl(),
    country: new FormControl(),
    state: new FormControl(),
    city: new FormControl(),
    street: new FormControl(),
    number: new FormControl(),
    userName: new FormControl(),
    password: new FormControl(),
    latitude: new FormControl(),
    longitude: new FormControl(),
    timeZone: new FormControl(),
    timeZoneOffset: new FormControl(),
    imagePath: new FormControl()
  });

  constructor(private userService: UserService, private route: ActivatedRoute) {

  }

  ngOnInit() {

    this.route.params.pipe(map((p) => p['id'])).subscribe((item) => {
      this.userId = parseInt(item);
    });

    this.userService.getUsersDetailed(this.userId!).subscribe((data) => {

      this.imagePath = data.imagePath;

      this.profileForm.patchValue({
        id: this.userId,
        title: data.title,
        name: data.name,
        email: data.email,
        birthDate: data.birthDate,
        phone: data.contact.phone,
        cell: data.contact.cell,
        documentType: data.document.type,
        documentValue: data.document.value,
        postCode: data.location.postCode,
        country: data.location.country,
        state: data.location.state,
        city: data.location.city,
        street: data.location.street,
        number: data.location.number,
        latitude: data.location.latitude,
        longitude: data.location.longitude,
        timeZone: data.location.timeZone,
        timeZoneOffset: data.location.timeZoneOffSet,
        imagePath: data.imagePath

      })
    })

  }

  onSubmit() {
    this.userService.updateUser(
      this.userId!,
      this.profileForm.value as UserDetail
    ).subscribe((data) => {

    })

  }



}
