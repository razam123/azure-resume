window.addEventListener ('DOMContentLoaded',(event)=> {

    getVisitCount(); 
})

const functionApiURL = 'https://aliraza-azureresume.azurewebsites.net/api/GetResumeTrigger?code=4_xwScj9ASkqYtvTwjv6hk4fJklU42PNQEMzQeftmc_GAzFu9WCKSQ%3D%3D';
const localfunctionApi = 'http://localhost:7071/api/GetResumeTrigger';

const getVisitCount = () => {

    let count =30; 
    fetch(functionApiURL).then(Response => {
        return Response.json()

    }).then(Response => {
        console.log("Website called function API")
        count = Response.count; 
        document.getElementById("counter").innerText = count;

    }).catch(function(error){

        console.log(error)
     });
     return count;
} 