# Como utilizar o .editorconfig

> Caso ainda não tenha o node instalado utilize o [NVM](https://github.com/coreybutler/nvm-windows)


1. Se for utilizar **VS Code**, deve ter o node instalado e instalar o pacote global do editorconfig
```cmd
npm install -g editorconfig
```
2. Depois instalar extensão para o **VS code**. [Extensão para VS code](https://marketplace.visualstudio.com/items?itemName=EditorConfig.EditorConfig)
3. Para o **VisualStudio** não é necessário esse procedimento



## Obter arquivo .editorconfig da branch **main**
1. dentro da branch com seu nome, faça o fetch para pegar as novas alterações da origin/main
```cmd
git fetch origin main
```
2. Realize o **MERGE** com origin/main, alterações da main vão estar aplicadas na sua branch
```cmd
git merge origin/main
```
3. Realize o pull para verificar que está tudo atualizado e depois o push
```
git pull
git push origin [nome-da-sua-branch]
```
4. Copie o arquivo **.editorconfig** para pasta **src** dentro da pasta com seu nome. Quando abrir o projeto abra essa pasta **src** ou através da solution.
5. **Faça o commit das alterações e crie um novo pull-request para verificarmos se tudo ficou correto!**
