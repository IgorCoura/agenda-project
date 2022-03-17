# Development workflow

## [Commit messages](https://www.conventionalcommits.org/en/v1.0.0/)

### Use imperative form

```
# Good
Use EF to retrieve inventory
```
```
# Bad
Used EF to retrieve inventory
```

### Try to communicate what the change does without having to look at the source code

```
# Good
Increase left padding between textbox and layout frame
```
```
# Bad
Adjust css
```

It is useful in many scenarios (e.g. multiple commits, several changes and refactors) to help reviewers understand what the committer was thinking.

### Avoid generic messages or messages without any context

```
# Bad
Fix this
Fix stuff
It should work now
Change stuff
Adjust css
```

### Commit message types

- feat (new feature)
- fix (bug fix)
- docs (changes to documentation)
- refactor (refactoring production code)
- test (adding missing tests, refactoring tests; no production code change)
- chore (updating grunt tasks etc; no production code change)

```
e.g.
- feat: Add new landing page
- fix: Correct invalid amount 
- docs: Correct spelling of CHANGELOG
- refactor: Change client report to use dapper
- test: Add integration test to login
- chore: Update git ignore
```

## [Luby Git Flow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)

### Develop and Master Branches
Instead of a single master branch, this workflow uses two branches to record the history of the project. The master branch stores the official release history, and the develop branch serves as an integration branch for features. 

### Feature Branches
Each new feature should reside in its own branch, which can be pushed to the central repository for backup/collaboration. But, instead of branching off of master, feature branches use develop as their parent branch. When a feature is complete, it gets merged back into develop via pull request. Features should never interact directly with master.

### Hotfix Branches
Maintenance or “hotfix” branches are used to quickly patch production releases. Hotfix branches are a lot like release branches and feature branches except they're based on master instead of develop. This is the only branch that should fork directly off of master. As soon as the fix is complete, it should be merged into both master and develop (or the current release branch).

### The overall flow of Gitflow is:
1. A develop branch is created from master
2. A release branch is created from develop
3. Feature branches are created from develop
4. When a feature is complete it is merged into the develop branch
5. When the release branch is done it is merged into develop and master
6. If an issue in master is detected a hotfix branch is created from master
7. Once the hotfix is complete it is merged to both develop and master

### Rules
- You should never commit directly to the develop/staging/master branch
- As you complete the sprint you can merge the develop branch into staging, and then at the master branch
- You must complete these merges using a pull request
- As much as possible, you should have at least two reviewers in your pull requests