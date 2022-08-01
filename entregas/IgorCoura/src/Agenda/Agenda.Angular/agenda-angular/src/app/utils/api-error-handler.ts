import { MatSnackBar } from "@angular/material/snack-bar";

export function apiErrorHandler(snackBar: MatSnackBar, error: any) {
    const e = error.errors as string[];
    const errorMessage = e.map(e => e).join('\n');
    snackBar.open(errorMessage,'Fechar', {
      duration: 10000,
    });
}