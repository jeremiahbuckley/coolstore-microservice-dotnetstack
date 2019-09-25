# coolstore-microservice-dotnetstack
This is a .Net version of the coolstore-microservice project

Original here: https://github.com/jbossdemocentral/coolstore-microservice

"Forked" - Aug 14, 2019, and will presumably drift from there unless resynced.

Status:
1. cart-service - builds. Run not tested.
2. catalog-service - builds, runs, and seems to return correct values.
3. coolstore-gw - not started
4. coolstore-ui - not started, should not have to do
5. docs - not started
6. inventory-service - builds, runs, seems to return correct values.
7. openshift - not started, may not have to do
8. pricing-service - builds, runs, and seems to return correct values.
9. pricing-service-model - builds. Added to the solution so that the cart-service and the pricing-service can communicate.
10. rating-service - not started, some stuff here with fabric8, which will have to be sorted out
11. review-service - builds, and runs and seems to return correct values. No automated qa built yet
12. sso-service - not started, hopefully we don't have to do anything with this