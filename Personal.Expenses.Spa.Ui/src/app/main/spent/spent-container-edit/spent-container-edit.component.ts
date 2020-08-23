//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SpentService } from '../spent.service';

@Component({
    selector: 'app-spent-container-edit',
    templateUrl: './spent-container-edit.component.html',
    styleUrls: ['./spent-container-edit.component.css'],
})
export class SpentContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private spentService: SpentService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.spentService.initVM();
    }

    ngOnInit() {

       
    }

}
