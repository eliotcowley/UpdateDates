# UpdateDates
I always forget to update the date field when I make edits to Microsoft documentation, and I wanted a way to have this done automatically whenever I add a file to a commit, so I wrote this program that updates the date field on any changed files to today's date.

Of course, if you still have to remember to run the program before you add the files, it doesn't really solve the problem, so you can add a PowerShell function to your **profile.ps1** file that does both in one step:

```posh
function ud {
    C:\Path\To\Executable
    Write-Host "Adding files..."
    git add .
    Write-Host "Done!"
}
```

Now whenever you make changes to a file and are ready to commit, simply call `ud` instead of `git add`.
