import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { CreateLoadRequest, LoadResponse, LoadService } from './load.service';

@Component({
  selector: 'app-loads',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './loads.html',
  styleUrl: './loads.css',
  standalone: true,
})
export class Loads {
  private fb = inject(FormBuilder);
  private loadService = inject(LoadService);

  loadForm = this.fb.nonNullable.group({
    customerId: ['', [Validators.required]],
    referenceNumbers: this.fb.array([this.createReferenceNumberFormGroup()]),
    commodities: this.fb.array([this.createCommodityFormGroup()]),
  });

  get referenceNumbers(): FormArray {
    return this.loadForm.get('referenceNumbers') as FormArray;
  }

  get commodities(): FormArray {
    return this.loadForm.get('commodities') as FormArray;
  }

  createReferenceNumberFormGroup(): FormGroup {
    return this.fb.nonNullable.group({
      type: ['', Validators.required],
      value: ['', Validators.required],
    });
  }

  addReferenceNumber(): void {
    this.referenceNumbers.push(this.createReferenceNumberFormGroup());
  }

  removeReferenceNumber(index: number): void {
    this.referenceNumbers.removeAt(index);
  }

  createCommodityFormGroup(): FormGroup {
    return this.fb.nonNullable.group({
      description: ['', Validators.required],
      weight: [0, [Validators.required, Validators.min(1)]],
      handlingInstructions: [''],
    });
  }

  addCommodity(): void {
    this.commodities.push(this.createCommodityFormGroup());
  }

  removeCommodity(index: number): void {
    this.commodities.removeAt(index);
  }

  validateGuid(control: AbstractControl): ValidationErrors | null {
    const guidRegex =
      /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i;
    if (control.value && !guidRegex.test(control.value)) {
      return { invalidGuid: true };
    }
    return null;
  }

  onSubmit() {
    if (this.loadForm.invalid) {
      // Mark all controls as touched to show validation errors
      this.loadForm.markAllAsTouched();
      return;
    }
    const formValue = this.loadForm.getRawValue() as CreateLoadRequest;
    this.loadService.createLoad(formValue).subscribe({
      next: (response: LoadResponse) => {
        // Load created successfully
        alert(`Load created successfully! Load ID: ${response.id}`);
        this.loadForm.reset();
        // Re-initialize the form arrays with single empty entries
        this.loadForm.setControl(
          'referenceNumbers',
          this.fb.array([this.createReferenceNumberFormGroup()]),
        );
        this.loadForm.setControl(
          'commodities',
          this.fb.array([this.createCommodityFormGroup()]),
        );
      },
      error: (error) => {
        // Handle error
        alert(
          'Error creating load: ' +
            (error.error?.message || error.message || 'Unknown error'),
        );
      },
    });
  }

  onSave() {
    alert('Save Draft functionality is not implemented yet.');
  }
}
