const URL = "https://localhost:7104/api/Student/";

let ID;
const nombreCompleto = document.getElementById('NombreCompleto');
const matricula = document.getElementById('Matricula');
const materia = document.getElementById('Materia');
const nota = document.getElementById('Nota')
const buttonAdd = document.getElementById('BtnAdd')
const btnVer = document.getElementById('btnWatch')
const btnUpdate = document.getElementById('btnUpdate')
const tbody = document.getElementById('tbody')



        buttonAdd.addEventListener('click', (e) =>{
        e.preventDefault();
        
        const data = {nombreCompleto:nombreCompleto.value,matricula:matricula.value,materia:materia.value,nota:nota.value};
            if (data.nombreCompleto && data.materia && data.matricula && data.nota !=""){
                if  (data.nota < 0 ||data.nota >100){
                    alert('Introduzca una calificacion valida')
                }
                else{

        const Jdata = JSON.stringify(data)
        

        
    fetch(URL,{
        method:'post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body:Jdata
    })
    .then(res => res.json())
    .then(datos => console.log(datos),
        Get()
    )
                }}
            else
            {
                alert("Favor de completar todos los campos")
            }

})

function Get(){
fetch(URL+"GetAll")
.then(res=> res.json())
.then (data => VerEstudiante(data.data))
}

    function VerEstudiante(data){

        data.forEach(element => {
            let tr = document.createElement("tr");
            let name = document.createElement("td");
            let matricula = document.createElement("td");
            let materia = document.createElement("td");
            let nota = document.createElement("td");

            let btnEdit = document.createElement("input");
            btnEdit.type = "button";
            btnEdit.value = "edit";
            btnEdit.classList ="btn btn-info"
            btnEdit.addEventListener('click', () => {
                GetData(element.id)
            })
            
            let btnDelete = document.createElement("input");
            btnDelete.type = "button";
            btnDelete.value = "delete";
            btnDelete.classList ="btn btn-outline-danger"
            btnDelete.addEventListener('click', ()=>{
                Eliminar(element.id)
            })
     
            name.innerHTML = "";
            matricula.innerHTML = "";
            materia.innerHTML = "";
            nota.innerHTML = "";

            name.innerHTML = element.nombreCompleto;
            matricula.innerHTML = element.matricula;
            materia.innerHTML = element.materia;
            nota.innerHTML = element.nota;
     
            tr.appendChild(name);
            tr.appendChild(matricula);
            tr.appendChild(materia);
            tr.appendChild(nota);
            tr.appendChild(btnEdit);
            tr.appendChild(btnDelete);
            
     
            tbody.appendChild(tr);

            btnVer.disabled = true;

        });
        
    }
//-------------------------------DELETE--------------------------------------
    function Eliminar(id){
        fetch(URL+id,{
            method: 'DELETE',
        })
        .then(res => res.json())
        .then(data => {
            VerEstudiante(data.data)
        })}

//----------------------------------UPDATE-----------------------------------------
 
// Obtener la infomacion del estudiante
        function GetData(id){
            fetch(URL+id)
            .then(res => res.json())
            .then (data => { 
                nombreCompleto.value = data.data.nombreCompleto;
                matricula.value = data.data.matricula;
                materia.value = data.data.materia;
                nota.value = data.data.nota;
                ID = data.data.id

               // ocultar los botones
                buttonAdd.classList.add('hide')
                btnVer.classList.add('hide')
                btnUpdate.classList.add('show')

        // actualizar los datos
                btnUpdate.addEventListener('click', (e) =>{
                    e.preventDefault();
                    const data = {id:ID,nombreCompleto:nombreCompleto.value,matricula:matricula.value,materia:materia.value,nota:nota.value};
                    const Jdata = JSON.stringify(data)

                    fetch(URL,{
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: Jdata
            })
            .then(res => res.json())
            .then (data =>{
                // location.reload();
                tbody.innerHTML = " ";
                
                Get();

                buttonAdd.classList.add('show')
                btnVer.classList.add('show')
                btnUpdate.classList.replace('show', 'hide')

            })
            
                })
            }) 
        }
